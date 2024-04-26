package com.example.coolpc;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class NetworkService {
    private static NetworkService mInstance;
    private static final String BASE_URL = "https://10.0.2.2:44351/";
    OkHttpClient okHttpClient = UnsafeOkHttpClient.getUnsafeOkHttpClient();
    private Retrofit mRetrofit;

    private NetworkService() {
        mRetrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .client(okHttpClient)
                .build();
    }

    public static NetworkService getInstance() {
        if (mInstance == null) {
            mInstance = new NetworkService();
        }
        return mInstance;
    }

    public CoolPCApi getJSONApi() {
        return mRetrofit.create(CoolPCApi.class);
    }
}
