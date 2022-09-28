import { Redirect, Route, Switch } from "react-router-dom";

// components

import FooterAdmin from "components/Footers/FooterAdmin.js";
import HeaderStats from "components/Headers/HeaderStats.js";
import AdminNavbar from "components/Navbars/AdminNavbar.js";
import Sidebar from "components/Sidebar/Sidebar.js";

// views

import Settings from "views/userAdmin/Settings";
import Tables from "views/userAdmin/Tables";

export default function UserAdmin() {
  return (
    <>
      <Sidebar />
      <div className="relative md:ml-64 bg-blueGray-100">
        <AdminNavbar />
        {/* Header */}
        <HeaderStats />
        <div className="px-4 md:px-10 mx-auto w-full -m-24">
          <Switch>
            <Route path="/user/settings" exact component={Settings} />
            <Route path="/user/tables" exact component={Tables} />
            <Redirect from="/user" to="/user/tables" />
          </Switch>
          <FooterAdmin />
        </div>
      </div>
    </>
  );
}
