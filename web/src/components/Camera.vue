<template>
  <div>
    <div @click="closeWindows()">
      <i style="font-size: 40px;" class="el-icon-close"></i>
    </div>
    <div class="demo-image__placeholder">
      <div class="block">
        <span class="demonstration"></span>
        <el-image :src="src"></el-image>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      src:
        "https://cube.elemecdn.com/6/94/4d3ea53c084bad6931a56d5158a48jpeg.jpeg",
    };
  },
  mounted: function() {
            const loading = this.$loading({
          lock: true,
          text: 'Loading',
          spinner: 'el-icon-loading',
          background: 'rgba(0, 0, 0, 0.7)'
        });
        setTimeout(() => {
          loading.close();
        }, 1000);
  },
  methods: {
    closeWindows() {
      closefrm();
    }
  }
};
</script>

<style scoped>
.el-icon-close {
  position: absolute;
  right: 0px;
  top: 0px;
}

.demo-image__placeholder {
  position: absolute;
  top: 15%;
  left: 15%;
  width: 70%;
}
</style>