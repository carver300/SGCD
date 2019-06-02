package com.example.sgcd;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Handler;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.widget.EditText;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;
import android.view.View;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import com.example.sgcd.Interface.SGCDAPI;
import com.example.sgcd.Model.Paciente;
import com.example.sgcd.Model.Usuario;

public class RegistroPacienteActivity extends AppCompatActivity {


    EditText editNombre;
    EditText editApepaterno;
    EditText editApematerno;
    RadioGroup radioGroup;
    EditText editEdad;
    EditText editAlergia;
    EditText editCalle;
    EditText editColonia;
    EditText editCodpostal;
    EditText editTelefono;
    EditText editCorreo;
    TextView ej;

    ProgressDialog progress;

    String sNombre,sPaterno,sMaterno,sAlergia,sCalle,sColonia,sCorreo,sTelefono,sEdad,sCodpostal,sSexo,ejemplo;

    Toast toast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registro_paciente);

        editNombre = findViewById(R.id.editNombre);
        editApepaterno = findViewById(R.id.editApepaterno);
        editApematerno = findViewById(R.id.editApematerno);
        radioGroup = findViewById(R.id.opciones_sexo);
        editEdad = findViewById(R.id.editEdad);
        editAlergia = findViewById(R.id.editAlergia);
        editCalle = findViewById(R.id.editCalle);
        editColonia = findViewById(R.id.editColonia);
        editCodpostal = findViewById(R.id.editCodPostal);
        editTelefono = findViewById(R.id.editTelefono);
        editCorreo = findViewById(R.id.editCorreo);
        ej = findViewById(R.id.ejemplo);

        progress = new ProgressDialog(RegistroPacienteActivity.this);

    }



    public void onClickRegistrar(View view){
        registrarPaciente();
    }

    private void tomarDatos(){

        sNombre = editNombre.getText().toString().trim();
        sPaterno = editApepaterno.getText().toString().trim();
        sMaterno = editApematerno.getText().toString().trim();
        sAlergia = editAlergia.getText().toString().trim();
        sEdad = editEdad.getText().toString().trim();
        sCalle = editCalle.getText().toString().trim();
        sColonia = editColonia.getText().toString().trim();
        sCodpostal = editCodpostal.getText().toString().trim();
        sCorreo = editNombre.getText().toString().trim();
        sTelefono = editTelefono.getText().toString().trim();
        ejemplo = ej.getText().toString().trim();



        int selected = radioGroup.getCheckedRadioButtonId();


        String mensaje = "";





        sSexo="masculity";




        mensaje += sNombre+ "  ";
        mensaje += sPaterno+ "  ";
        mensaje += sMaterno+ "  ";
        mensaje += sAlergia+ "  ";
        mensaje += sEdad+ "  ";
        mensaje += sCalle+ "  ";
        mensaje += sColonia+ "  ";
        mensaje += sCodpostal+ "  ";
        mensaje += sCorreo+ "  ";
        mensaje += sTelefono+ "  ";
        mensaje += sSexo+ "  ";

        ej.setText(mensaje);

        mostrarMensajeToast(mensaje);

    }

    private void registrarPaciente(){
        tomarDatos();
        progress.setTitle("Cargando");
        progress.setMessage("Espere un momento");
        progress.show();
        Retrofit  retrofit = new Retrofit.Builder()
                .baseUrl("https://SGCD.azurewebsites.net/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        SGCDAPI sgcd = retrofit.create(SGCDAPI.class);

        Call<Integer> call = sgcd.registrarPaciente(new Paciente(sNombre,sPaterno,sMaterno,sSexo,sEdad,sCalle,sColonia,sCodpostal,sTelefono,sCorreo,sAlergia));

        call.enqueue(new Callback<Integer>() {
            @Override
            public void onResponse(Call<Integer> call, Response<Integer> response) {

               // mostrarMensajeToast(response.body().toString());

                if(response.body().intValue() == 1) {


                    mostrarMensajeToast("Paciente registrado");
                    progress.dismiss();
                    Intent myIntent = new Intent(getBaseContext(), MainActivity.class);
                    startActivity(myIntent);

                }
                else if(response.body().intValue() == 2){
                    progress.dismiss();
                    mostrarMensajeToast("El telefono usado ya existe");
                }
                else if(response.body().intValue() == 3){
                    progress.dismiss();
                    mostrarMensajeToast("El correo usado ya existe");
                }
                else{
                    mostrarMensajeToast("NO FUNCIONO "+response.body().toString() );
                }
            }

            @Override
            public void onFailure(Call<Integer> call, Throwable t) {
                mostrarMensajeToast("Se presento el error "+t.getMessage());
            }
        });
    }


    private void mostrarMensajeToast(String sMensaje){
        toast = Toast.makeText(this,sMensaje,Toast.LENGTH_LONG);
        toast.setGravity(Gravity.TOP,0,0);
        toast.show();
    }

}
