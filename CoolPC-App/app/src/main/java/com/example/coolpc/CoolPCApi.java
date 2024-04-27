package com.example.coolpc;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface CoolPCApi {
    @POST("/customers")
    public Call<Customer> postCustomer(@Body Customer data);
    @GET("/customers")
    public Call<List<Customer>> getCustomers();
}
