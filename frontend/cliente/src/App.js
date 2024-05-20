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
 /*
  const limpiarPantalla=()=>{
    document.body.innerHTML="";
  }*/
  const logiarse=(correo,password)=>{
    console.log(correo)
    console.log(password)
    
    fetch("https://localhost:7036/login?correo="+correo+"&password="+password,{method:'POST'})
      .then((res) => res.json())
      .then((data) => console.log(data));
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

      </header>
       
    </div>
  );
}

export default App;
