package com.example.coolpc;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    private static final String PREFS_FILE = "Account";
    private static final String PREFS_ID = "UserID";

    SharedPreferences settings;
    Button loginButton;

    EditText loginEditText;
    EditText passwordEditText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        settings = getSharedPreferences(PREFS_FILE, MODE_PRIVATE);

        TextView doestHaveAnAccountTextView = findViewById(R.id.doesnt_have_acc);
        doestHaveAnAccountTextView.setOnClickListener(v -> {
            Intent intent = new Intent(this, RegistrationActivity.class);
            startActivity(intent);
            finish();
        });

        loginEditText = findViewById(R.id.login_editText);
        passwordEditText = findViewById(R.id.password_editText);


        loginButton = findViewById(R.id.log_in_button);
        loginButton.setOnClickListener(v -> {

            String login = loginEditText.getText().toString();
            String password = passwordEditText.getText().toString();
            ArrayList<Customer> customerList = new ArrayList<Customer>();

            NetworkService networkService = NetworkService.getInstance();
            CoolPCApi api = networkService.getJSONApi();
            Call<List<Customer>> call = api.getCustomers();
            call.enqueue(new Callback<List<Customer>>() {
                @Override
                public void onResponse(Call<List<Customer>> call, Response<List<Customer>> response) {
                    customerList.addAll(response.body());
                    Customer customer = customerList.stream().filter(a -> a.getLogin() == login).findFirst().orElse(null);
                    if (customer == null) {
                        Toast.makeText(getApplicationContext(),"Такой пользователь не найден!", Toast.LENGTH_LONG).show();
                        return;
                    }
                    else if (customer.getPassword().equals(password)) {
                        SharedPreferences.Editor prefEditor = settings.edit();
                        prefEditor.putLong(PREFS_ID,customer.getCustomerId());
                        prefEditor.apply();
                        Intent intent = new Intent(getApplicationContext(), HomeActivity.class);
                        startActivity(intent);
                        finish();
                    }
                    else {
                        Toast.makeText(getApplicationContext(),"Неверный пароль!", Toast.LENGTH_LONG).show();
                        return;
                    }
                }

                @Override
                public void onFailure(Call<List<Customer>> call, Throwable t) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(getApplicationContext());
                    builder.setTitle("Произошла ошибка при попытке связаться с сервером!");
                    builder.setMessage(t.getMessage());
                    builder.setCancelable(false);
                }
            });
        });
    }
}