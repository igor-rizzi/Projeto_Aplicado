import { Redirect, Route, Switch } from "react-router-dom";

// components

import FooterAdmin from "components/Footers/FooterAdmin.js";
import AdminNavbar from "components/Navbars/AdminNavbar.js";
import Sidebar from "components/Sidebar/Sidebar.js";

// views

import Dashboard from "views/userAdmin/Dashboard";
import Settings from "views/userAdmin/Settings";
import Tables from "views/userAdmin/Tables";

export default function UserAdmin() {
  return (
    <>
      <Sidebar />
      <div className="relative md:ml-64 bg-blueGray-100">
        <AdminNavbar />
        {/* Header */}
        <div className="px-4 md:px-10 mx-auto w-full -m-24">
          <Switch>
            <Route path="/user" exact component={Dashboard} />
            <Route path="/user/tables" exact component={Tables} />
            <Route path="/user/settings" exact component={Settings} />
            <Redirect from="/user" to="/user/tables" />
          </Switch>
          <FooterAdmin />
        </div>
      </div>
    </>
  );
}
