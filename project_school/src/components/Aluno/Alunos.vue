<template>
  <div>
    <Titulo :texto="professorid != undefined ? 'Professor: ' + professor.nome : 'Todos os alunos: '"/>
    <div v-if="professorid != undefined">
      <input class="input" type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="adicionarAluno()"/>
      <button class="btn btnInput" @click="adicionarAluno()">Adicionar</button>
    </div>
    <table>
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Sobrenome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer" class="colPequeno">{{aluno.id}}</router-link>
          <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">{{aluno.nome}}</router-link>
          <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">{{aluno.sobrenome}}</router-link>
          <td class="colPequeno">
            <button class="btnDanger" @click="removerAluno(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!alunos.length">Nenhum registro encontrado.</tfoot>
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
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: [],
    };
  },
  created() {
    if(this.professorid ) {
      this.carregarProfessores();
      this.$http
        .get("http://localhost:3000/alunos?professor.id=" + this.professorid)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:3000/alunos")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    adicionarAluno() {
      let _aluno = {
        nome: this.nome,
        professor: {
          id: this.professor.id,
          nome: this.professor.nome,
          sobrenome: this.professor.sobrenome
        }
      };

      this.$http
        .post("http://localhost:3000/alunos", _aluno)
        .then((res) => res.json())
        .then((alunoRetornado) => {
          this.alunos.push(alunoRetornado);
        });

      //this.alunos.push(_aluno);
      //this.nome = "";

      //this.alunos.forEach(element => {
      //  console.log(element);
      //});
    },

    removerAluno(aluno) {
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:3000/professores/" + this.professorid)
        .then((res) => res.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>

<style scoped>
input {
  width: calc(100%-150px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  color: white;
  background-color: rgb(116,115,115);
}

.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
