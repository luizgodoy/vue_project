<template>
  <div>
    <Titulo texto="Alunos" />
    <input
      class="btnInput"
      type="text"
      placeholder="Nome do Aluno"
      v-model="nome"
      v-on:keyup.enter="adicionarAluno()"
    />
    <button class="btn btnInput" @click="adicionarAluno()">Adicionar</button>
    <table>
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}}</td>
          <td>
            <button class="btn" @click="removerAluno(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="!alunos.length">Nenhum registro.</tfoot>
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
      nome: "Alunos",
      alunos: [],
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then((res) => res.json())
      .then((alunos) => (this.alunos = alunos));
  },
  props: {},
  methods: {
    adicionarAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
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
  },
};
</script>

<style scoped>
</style>
