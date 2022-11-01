import CardTable from "components/Cards/CardTable.js";
import { useState } from "react";

export default function Tables() {
  const [vagas, setVagas] = useState();

  return (
    <>
      <div className="flex flex-wrap mt-4">
        <div className="w-full mb-12 px-4">
          <CardTable item={vagas} />
        </div>
      </div>
    </>
  );
}
