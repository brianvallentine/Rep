using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0004S
{
    public class M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1 : QueryBasis<M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.R_PESSOA_TIPORELAC
            VALUES (:WS-COD-PES-004 ,
            :PRDSIVPF-COD-RELAC)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES ({FieldThreatment(this.WS_COD_PES_004)} , {FieldThreatment(this.PRDSIVPF_COD_RELAC)})";

            return query;
        }
        public string WS_COD_PES_004 { get; set; }
        public string PRDSIVPF_COD_RELAC { get; set; }

        public static void Execute(M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1 m_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1)
        {
            var ths = m_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}