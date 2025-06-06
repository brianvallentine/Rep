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
    public class M_70000_00_RELAC_TIP_DB_SELECT_1_Query1 : QueryBasis<M_70000_00_RELAC_TIP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA ,
            COD_RELAC
            INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA ,
            :DCLR-PESSOA-TIPORELAC.COD-RELAC
            FROM SEGUROS.R_PESSOA_TIPORELAC
            WHERE COD_PESSOA = :WS-COD-PES-004
            AND COD_RELAC = :PRDSIVPF-COD-RELAC
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA 
							,
											COD_RELAC
											FROM SEGUROS.R_PESSOA_TIPORELAC
											WHERE COD_PESSOA = '{this.WS_COD_PES_004}'
											AND COD_RELAC = '{this.PRDSIVPF_COD_RELAC}'
											WITH UR";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string COD_RELAC { get; set; }
        public string PRDSIVPF_COD_RELAC { get; set; }
        public string WS_COD_PES_004 { get; set; }

        public static M_70000_00_RELAC_TIP_DB_SELECT_1_Query1 Execute(M_70000_00_RELAC_TIP_DB_SELECT_1_Query1 m_70000_00_RELAC_TIP_DB_SELECT_1_Query1)
        {
            var ths = m_70000_00_RELAC_TIP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_70000_00_RELAC_TIP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_70000_00_RELAC_TIP_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_PESSOA = result[i++].Value?.ToString();
            dta.COD_RELAC = result[i++].Value?.ToString();
            return dta;
        }

    }
}