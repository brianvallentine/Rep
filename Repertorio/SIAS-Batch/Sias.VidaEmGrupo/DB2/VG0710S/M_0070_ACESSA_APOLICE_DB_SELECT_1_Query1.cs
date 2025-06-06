using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0710S
{
    public class M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT MODALIDA, RAMO
            INTO :MODALIDA, :RAMO
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MODALIDA
							, RAMO
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.NUM_APOLICE}'";

            return query;
        }
        public string MODALIDA { get; set; }
        public string RAMO { get; set; }
        public string NUM_APOLICE { get; set; }

        public static M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1 Execute(M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1 m_0070_ACESSA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_0070_ACESSA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MODALIDA = result[i++].Value?.ToString();
            dta.RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}