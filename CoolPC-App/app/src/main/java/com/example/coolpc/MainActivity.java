package com.example.coolpc;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.LinearGradient;
import android.graphics.Shader;
import android.os.Bundle;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private static final String PREFS_FILE = "Account";
    private static final String PREFS_ID = "UserID";

    SharedPreferences settings;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        settings = getSharedPreferences(PREFS_FILE, MODE_PRIVATE);
        long customerID = settings.getLong(PREFS_ID, -1);
        if (customerID == -1) {
            Intent intent = new Intent(this, RegistrationActivity.class);
            startActivity(intent);
        }
        else {
            Intent intent = new Intent(this, HomeActivity.class);
            startActivity(intent);
        }
    }
}