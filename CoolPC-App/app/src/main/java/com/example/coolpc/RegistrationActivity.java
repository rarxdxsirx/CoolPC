package com.example.coolpc;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.MalformedURLException;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;

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
            //todo: add password confirm check
            Customer customer = new Customer();
            customer.setFirstName(firstNameEditText.getText().toString());
            customer.setSecondName(secondNameEditText.getText().toString());
            customer.setLogin(loginEditText.getText().toString());
            customer.setEmail(emailEditText.getText().toString());
            customer.setPassword(passwordEditText.getText().toString());
            customer.setCustomerId(7);
            Call<Customer> call = api.postData(customer);
            call.enqueue(new Callback<Customer>() {
                @Override
                public void onResponse(Call<Customer> call, Response<Customer> response) {
                    if (response.isSuccessful()) {
                        Toast.makeText(getApplicationContext(),"Пользователь зарегистрирован", Toast.LENGTH_LONG).show();
                        Intent intent = new Intent(getApplicationContext(), HomeActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }

                @Override
                public void onFailure(Call<Customer> call, Throwable t) {
                    Toast.makeText(getApplicationContext(),"Пользователь не зарегистрирован " + t.getMessage().toString(), Toast.LENGTH_LONG).show();
                    emailEditText.setText(t.getMessage());
                }
            });
        });
    }
}