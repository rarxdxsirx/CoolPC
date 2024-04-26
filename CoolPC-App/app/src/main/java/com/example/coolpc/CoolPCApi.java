package com.example.coolpc;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface CoolPCApi {
    @POST("/customers")
    public Call<Customer> postData(@Body Customer data);
}
