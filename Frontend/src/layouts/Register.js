import { Redirect, Route, Switch } from "react-router-dom";

// components

import FooterSmall from "components/Footers/FooterSmall.js";
import Navbar from "components/Navbars/RegisterNavbar.js";

// views

import Register from "views/auth/Register.js";
import RegisterCnpj from "views/auth/RegisterCnpj.js";

export default function RegisterLayout() {
  return (
    <>
      <Navbar transparent />
      <main>
        <section className="relative w-full h-full py-40 min-h-screen">
          <div className="absolute top-0 w-full h-full bg-blueGray-800 bg-no-repeat bg-full"></div>
          <Switch>
            <Route path="/register" exact component={Register} />
            <Route path="/registerCnpj" exact component={RegisterCnpj} />
            <Redirect from="/register" to="/register" />
          </Switch>
          <FooterSmall absolute />
        </section>
      </main>
    </>
  );
}
