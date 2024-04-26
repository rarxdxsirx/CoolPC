package com.example.coolpc;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.FrameLayout;
import android.widget.LinearLayout;

public class AccountActivity extends AppCompatActivity {

    LinearLayout homeButton;
    LinearLayout cartButton;
    LinearLayout catalogButton;
    LinearLayout accountButton;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_account);

        FrameLayout navbar = findViewById(R.id.navbar);
        homeButton = navbar.findViewById(R.id.home);
        homeButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), HomeActivity.class);
            startActivity(intent);
            finish();
        });
        cartButton = navbar.findViewById(R.id.cart);
        cartButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), CartActivity.class);
            startActivity(intent);
            finish();
        });
        catalogButton = navbar.findViewById(R.id.catalog);
        catalogButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), CatalogActivity.class);
            startActivity(intent);
            finish();
        });
        accountButton = navbar.findViewById(R.id.account);
        accountButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), AccountActivity.class);
            startActivity(intent);
            finish();
        });
    }
}