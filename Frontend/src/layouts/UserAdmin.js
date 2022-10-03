import { Redirect, Route, Switch } from "react-router-dom";

// components

import FooterAdmin from "components/Footers/FooterAdmin.js";
import SidebarUser from "components/Sidebar/SidebarUser.js";

// views

import HeaderStats from "components/Headers/HeaderStats";
import UserNavbar from "components/Navbars/UserNavbar";
import Dashboard from "views/userAdmin/Dashboard";
import Settings from "views/userAdmin/Settings";
import Tables from "views/userAdmin/Tables";

export default function UserAdmin() {
  return (
    <>
      <SidebarUser />
      <div className="relative md:ml-64 bg-blueGray-100">
        <UserNavbar />
        {/* Header */}
        <HeaderStats />
        <div className="px-4 md:px-10 mx-auto w-full -m-24">
          <Switch>
            <Route path="/usuario" exact component={Dashboard} />
            <Route path="/usuario/vagas" exact component={Tables} />
            <Route path="/usuario/configuracoes" exact component={Settings} />
            <Redirect from="/usuario" to="/usuario" />
          </Switch>
          <FooterAdmin />
        </div>
      </div>
    </>
  );
}
