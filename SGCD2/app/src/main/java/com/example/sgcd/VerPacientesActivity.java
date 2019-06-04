package com.example.sgcd;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.Gravity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioGroup;
import android.widget.Toast;
import android.widget.TextView;
import android.content.Intent;

import java.io.IOException;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import com.example.sgcd.Model.Post;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

import com.example.sgcd.Interface.SGCDAPI;
import com.example.sgcd.Model.Paciente;

import org.json.JSONArray;

public class VerPacientesActivity extends AppCompatActivity {



    EditText idpaciente;
    TextView editNombre;
    TextView editApepaterno;
    TextView editApematerno;
    TextView editSexo;
    TextView editEdad;
    TextView editAlergia;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ver_pacientes);

        idpaciente = findViewById(R.id.txtPaciente);
        editNombre = findViewById(R.id.txtNombre);
        editApepaterno = findViewById(R.id.txtApaterno);
        editApematerno = findViewById(R.id.txtAmaterno);
        editSexo = findViewById(R.id.txtSexo);
        editEdad = findViewById(R.id.txtEdad);
        editAlergia = findViewById(R.id.txtSexo);



    }

    public void onClick(View view){
        getPosts();
    }



    private void getPosts(){


        Retrofit  retrofit = new Retrofit.Builder()
                .baseUrl("http://178.128.13.15:8001/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        SGCDAPI sgcd= retrofit.create(SGCDAPI.class);

        String a = idpaciente.getText().toString();
        int id = Integer.parseInt(a);

        Call<Paciente> call = sgcd.getPaciente(id);

        call.enqueue(new Callback<Paciente>() {
            @Override
            public void onResponse(Call<Paciente> call, Response<Paciente> response) {
                        Paciente pa = response.body();
                        editNombre.setText(response.body().getNombre());
                        editApepaterno.setText(response.body().getApepaterno());
                        editApematerno.setText(response.body().getApematerno());
                        editSexo.setText(response.body().getSexo());
                        editEdad.setText(response.body().getEdad());
                        editAlergia.setText(response.body().getAlergia());

                        llenarDatos(pa);
            }

            @Override
            public void onFailure(Call<Paciente> call, Throwable t) {

            }
        });
    }

    public void llenarDatos(Paciente pa){
        editNombre.setText(pa.getNombre());
        editApepaterno.setText(pa.getApepaterno());
        editApematerno.setText(pa.getApematerno());
        editSexo.setText(pa.getSexo());
        editEdad.setText(pa.getEdad());
        editAlergia.setText(pa.getAlergia());
    }

}
