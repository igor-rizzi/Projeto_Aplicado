import axios from "axios";

const Api = axios.create({
  baseURL: "https://127.0.0.1:7018/api",
});

export default Api;
