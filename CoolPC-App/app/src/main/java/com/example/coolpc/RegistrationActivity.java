package com.example.coolpc;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RegistrationActivity extends AppCompatActivity {

    EditText loginEditText;
    EditText emailEditText;
    EditText firstNameEditText;
    EditText secondNameEditText;
    EditText phoneNumberEditText;
    EditText passwordEditText;
    EditText passwordConfirmEditText;
    Button registrateButton;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);

        TextView alreadyHaveAnAccountTextView = findViewById(R.id.already_have_acc_button);
        alreadyHaveAnAccountTextView.setOnClickListener(v -> {
            Intent intent = new Intent(this, LoginActivity.class);
            startActivity(intent);
            finish();
        });

        loginEditText = findViewById(R.id.login_editText);
        emailEditText = findViewById(R.id.email_editText);
        firstNameEditText = findViewById(R.id.first_name_editText);
        secondNameEditText = findViewById(R.id.second_name_editText);
        phoneNumberEditText = findViewById(R.id.phone_editText);
        passwordEditText = findViewById(R.id.password_editText);
        passwordConfirmEditText = findViewById(R.id.password_confirm_editText);
        registrateButton = findViewById(R.id.registrate_button);

        registrateButton.setOnClickListener(v -> {
            NetworkService networkService = NetworkService.getInstance();
            CoolPCApi api = networkService.getJSONApi();
            boolean isFormValid = true;
            String errorMessage = "";
            Customer customer = new Customer();
            customer.setFirstName(firstNameEditText.getText().toString());
            if (customer.getFirstName().length() <= 0 || customer.getFirstName().toString().matches(".*\\d.*")) {
                isFormValid = false;
                errorMessage += "Введено неверное имя пользователя";
            }
            customer.setSecondName(secondNameEditText.getText().toString());
            if (customer.getSecondName().length() <= 0 || customer.getSecondName().toString().matches(".*\\d.*")) {
                isFormValid = false;
                errorMessage += "Введена неверная фамилия пользователя\n";
            }
            customer.setLogin(loginEditText.getText().toString());
            customer.setEmail(emailEditText.getText().toString());
            if (!isValidEmail(customer.getEmail())) {
                isFormValid = false;
                errorMessage += "Введеная неверная почта пользователя\n";
            }
            customer.setPassword(passwordEditText.getText().toString());
            if (!isValidPassword(customer.getPassword())) {
                isFormValid = false;
                errorMessage += "Пароль должен быть сложнее!\n";
            }
            if (!passwordConfirmEditText.getText().toString().equals(customer.getPassword())) {
                isFormValid = false;
                errorMessage += "Пароли не совпадают";
            }
            customer.setCustomerId(7); // get last customer id from api
            if (!isFormValid) {
                AlertDialog.Builder builder = new AlertDialog.Builder(getApplicationContext());
                builder.setTitle("Ошибка при регистрации!");
                builder.setMessage(errorMessage);
                builder.setCancelable(false);
                return;
            }

            Call<Customer> call = api.postCustomer(customer);
            call.enqueue(new Callback<Customer>() {
                @Override
                public void onResponse(Call<Customer> call, Response<Customer> response) {
                    if (response.isSuccessful()) {
                        Toast.makeText(getApplicationContext(),"Пользователь зарегистрирован", Toast.LENGTH_LONG).show();
                        Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }

                @Override
                public void onFailure(Call<Customer> call, Throwable t) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(getApplicationContext());
                    builder.setTitle("Произошла ошибка при попытке связаться с сервером!");
                    builder.setMessage(t.getMessage());
                    builder.setCancelable(false);
                    return;
                }
            });
        });
    }

    public final static boolean isValidEmail(CharSequence target) {
        return !TextUtils.isEmpty(target) && android.util.Patterns.EMAIL_ADDRESS.matcher(target).matches();
    }

    public static boolean isValidPassword(CharSequence password) {
        if (password.length() < 8)
            return false;
        Pattern pattern;
        Matcher matcher;
        final String PASSWORD_PATTERN = "^(?=.*[0-9])(?=.*[@#$%^&+=!])(?=\\S+$).{4,}$"; // (?=.*[A-Z])
        pattern = Pattern.compile(PASSWORD_PATTERN);
        matcher = pattern.matcher(password);
        return matcher.matches();
    }
}