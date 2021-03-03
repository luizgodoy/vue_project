<template>
  <div>
    <titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="visualizando">
        <button v-show="visualizando" class="btn btnEditar" @click="editar()">Editar</button>
        <button v-show="!visualizando" class="btn btnSalvar" @click="salvar()">Salvar</button>
        <button v-show="!visualizando" class="btn btnCancelar" @click="cancelar()">Cancelar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text" /> 
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text" /> 
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nascimento:</td>
          <td>
            <label v-if="visualizando">{{ aluno.dataNascimento }}</label>
            <input v-else v-model="aluno.dataNascimento" type="text" /> 
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
              <label v-if="visualizando">{{ aluno.professor.nome }} {{ aluno.professor.sobrenome }}</label>
              <select v-else v-model="aluno.professor">
                <option v-for="(professor, index) in this.professores" 
                    :key="index" v-bind:value="professor"> 
                    {{professor.nome}} {{professor.sobrenome}}
                </option>
              </select>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo.vue";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      aluno: {},
      idAluno: this.$route.params.idAluno,
      professores: [],
      visualizando: true
    };
  },
  props: {},

  created() {
    this.$http
        .get("http://localhost:3000/alunos/" + this.idAluno)
        .then((res) => res.json())
        .then((aluno) => (this.aluno = aluno));

    this.$http
        .get("http://localhost:3000/professores")
        .then((res) => res.json())
        .then((professores) =>  this.professores = professores);
    },

    methods: {
        editar(){
            this.visualizando = false;
        },

        salvar() {
            let _alunoEditar = {
                id: this.aluno.id,
                nome: this.aluno.nome,
                sobrenome: this.aluno.sobrenome,
                dataNascimento: this.aluno.dataNascimento,
                professor: this.aluno.professor
            }

            this.$http.put(`http://localhost:3000/alunos/${_alunoEditar.id}`, _alunoEditar);
            this.cancelar();
        },

        cancelar(){
            this.visualizando = true;
        }
    },  
}
</script>

<style scoped>

.colPequeno {
    width: 20%;
    text-align: right;
    background-color: rgb(128,217,245);
    font-weight: bold;
}

input, select {
    margin: 0px;
    padding: 5px, 10px;
    font-size: 0.9em;
    font-family: 'Courier New', Courier, monospace;
    border: 1px solid silver;
    border-radius: 5px;
    width: 95%;
    background-color: rgb(245, 245, 245);
}

select {
    height: 38px;
    width: 100%;
}

.btnEditar{
    float: right;
    background-color: rgb(79,196,68);
}

.btnSalvar{
    float: right;
    background-color: rgb(79,196,68);
}

.btnCancelar{
    float: right;
    background-color: rgb(76,186,249);
}

</style>