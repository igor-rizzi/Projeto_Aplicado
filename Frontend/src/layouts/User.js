import { Redirect, Route, Switch } from "react-router-dom";

// components
import FooterAdmin from "components/Footers/FooterAdmin";
import UserNavbar from "components/Navbars/UserNavbar";
import SidebarUser from "components/Sidebar/SidebarUser";

// views

import HeaderUser from "components/Headers/HeaderUser";
import MinhasVagas from "views/userAdmin/MinhasVagas";
import Settings from "views/userAdmin/Settings";
import Vagas from "views/userAdmin/Vagas";

export default function User() {
  return (
    <>
      <SidebarUser />
      <div className="relative md:ml-64 bg-blueGray-100">
        <UserNavbar />
        {/* Header */}
        <HeaderUser />
        <div className="px-4 md:px-10 mx-auto w-full -m-24">
          <Switch>
            <Route path="/usuario/vagas" exact component={Vagas} />
            <Route path="/usuario/minhasVagas" exact component={MinhasVagas} />
            <Route path="/usuario/configuracoes" exact component={Settings} />
            <Redirect from="/usuario" to="/usuario/vagas" />
          </Switch>
          <FooterAdmin />
        </div>
      </div>
    </>
  );
}
