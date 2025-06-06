using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0340B
{
    public class M_0000_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CONVENIO,
            NSA_CONVENIO,
            VERSAO_LAYOUT
            INTO :PARM-CODCONV,
            :PARM-NSA,
            :PARM-VERSAO
            FROM SEGUROS.V0CONVSUCOV
            WHERE COD_CONVENIO = 6131
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CONVENIO
							,
											NSA_CONVENIO
							,
											VERSAO_LAYOUT
											FROM SEGUROS.V0CONVSUCOV
											WHERE COD_CONVENIO = 6131";

            return query;
        }
        public string PARM_CODCONV { get; set; }
        public string PARM_NSA { get; set; }
        public string PARM_VERSAO { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_2_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_2_Query1 m_0000_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.PARM_CODCONV = result[i++].Value?.ToString();
            dta.PARM_NSA = result[i++].Value?.ToString();
            dta.PARM_VERSAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}