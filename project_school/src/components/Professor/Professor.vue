<template>
  <div>
    <Titulo texto="Professores" />
    <table>
      <thead>
        <th>ID</th>
        <th>Nome</th>
        <th>Sobrenome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <td class="colPequeno">{{ professor.id }}</td>
          <router-link
            :to="`/alunos/${professor.id}`"
            tag="td"
            style="cursor: pointer">
            {{ professor.nome }}
          </router-link>
          <router-link
            :to="`/alunos/${professor.id}`"
            tag="td"
            style="cursor: pointer">
            {{ professor.sobrenome }}
            </router-link>
          <td class="colPequeno">{{ professor.qtdAlunos }}</td>
        </tr>
      </tbody>
      <tfoot v-if="!Professores.length">
        Nenhum registro encontrado.
      </tfoot>
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
      Professores: [],
      Alunos: [],
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then((res) => res.json())
      .then((alunos) => {
        this.Alunos = alunos;
        this.carregarProfessores();
      });
  },
  props: {},
  methods: {
    pegarQtdAlunosPorProfessor() {
      this.Professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          sobrenome: professor.sobrenome,
          qtdAlunos: this.Alunos.filter(
            (aluno) => aluno.professor.id == professor.id
          ).length,
        };
        this.Professores[index] = professor;
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:3000/professores")
        .then((res) => res.json())
        .then((professor) => {
          this.Professores = professor;
          this.pegarQtdAlunosPorProfessor();
        });
    },
  },
};
</script>

<style scoped>
</style>