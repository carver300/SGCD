package com.example.sgcd;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;
import android.widget.TextView;

import java.io.IOException;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import com.example.sgcd.Model.Post;
import java.util.List;

import com.example.sgcd.Interface.SGCDAPI;

public class LoginActivity extends AppCompatActivity {

    private TextView jsonText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        jsonText = findViewById(R.id.jsonText);
        getPosts();
    }

    private void getPosts(){
        Retrofit  retrofit = new Retrofit.Builder()
                .baseUrl("https://SGCD.azurewebsites.net/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        SGCDAPI sgcd= retrofit.create(SGCDAPI.class);

        Call<List<Post>> call = sgcd.getPost();

        call.enqueue(new Callback<List<Post>>() {
            @Override
            public void onResponse(Call<List<Post>> call, Response<List<Post>> response) {
                if(!response.isSuccessful()){
                    jsonText.setText("Codigo: "+response.code());
                }

                List<Post> postList = response.body();

                for(Post post: postList){
                    String content = "";
                    content += "ID SERVICIO"+ post.getId_servicio() +"\n";
                    content += "Nombre"+ post.getNombre()+"\n";
                    content += "Descripcion"+ post.getDescripcion()+"\n";
                    content += "Precio"+ post.getPrecio()+"\n";
                    content += "TiempoEstimado"+ post.getTiempoestimado()+"\n";
                    jsonText.append(content);
                }
            }

            @Override
            public void onFailure(Call<List<Post>> call, Throwable t) {
                jsonText.setText(t.getMessage());
            }
        });
    }

}
