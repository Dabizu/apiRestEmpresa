//import logo from './logo.svg';
import './App.css';
import React,{useState} from "react";

function App() {
  const [correo,setCorreo]=useState("");
  const [password,setPassword]=useState("");
  /*
  fetch("/api")
      .then((res) => res.json())
      .then((data) => setData(data.message));
  */
  var login=document.getElementById("login");
  const aparecerLogin=()=> {
    login.style.display = "block";
  }

  const desaparecerLogin=()=> {
    login.style.display = "none";
  }
  var tabla=document.getElementById("tabla");
  const aparecerTabla=()=> {
    tabla.style.display = "block";
  }

  const desaparecerTabla=()=> {
    tabla.style.display = "none";
  }
  desaparecerTabla();
  /*const limpiarPantalla=()=>{
    document.body.innerHTML="";
  }*/
  const logiarse=(correo,password)=>{
    console.log(correo)
    console.log(password)
    
    fetch("https://localhost:7036/login?correo="+correo+"&password="+password,{method:'POST'})
      .then((res) => res.json())
      .then((data) =>{
        if(data===true){
          //limpiarPantalla();
          desaparecerLogin();
          aparecerTabla()
          listarUsuarios()
          
        }else{
          alert("no es posible el logeo por que su correo o password estan mal")
        }
      });
  }
  const listarUsuarios=()=>{
    fetch("https://localhost:7036/listarUsuarios")
      .then((res) => res.json())
      .then((data) => {
        //creamos la tabña
        var tabla='';
        data.forEach(element => {
          tabla=tabla+'<tr>'+
            '<th scope="row">'+element.id+'</th>'+
            '<td>'+element.username+'</td>'+
            '<td>'+element.genero+'</td>'+
            '<td>'+element.edad+'</td>'+
            '<td>'+element.correo+'</td>'+
          '</tr>'
        });
        document.getElementById("bodytabla").innerHTML=tabla;
      
      });
  }
  return (
    <div className="App">
      <header className="App-header">
      <div id="login">
        <br/>
        <input type="text" class="form-control" id="correo" placeholder="correo" aria-describedby="basic-addon1" value={correo} onChange={e => setCorreo(e.target.value)}></input>
        <br/>
        <input type="text" class="form-control" id="password" placeholder="password" aria-describedby="basic-addon1" value={password} onChange={e => setPassword(e.target.value)}></input>
        <br/>
        <button type="button" class="btn btn-outline-light" onClick={()=>{logiarse(correo,password)}}>Entrar</button>
      </div>

      <div id="tabla">
      <table class="table"><thead><tr>
        <th scope="col">id</th>
        <th scope="col">username</th>
        <th scope="col">genero</th>
        <th scope="col">edad</th>
        <th scope="col">correo</th>
        
        </tr></thead>
        <tbody id="bodytabla">

        </tbody>
        </table>
      </div>

      </header>
       
    </div>
  );
}

export default App;
