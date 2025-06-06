using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class M_300_150_240_COBERTURAS_DB_SELECT_2_Query1 : QueryBasis<M_300_150_240_COBERTURAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            RAMO,
            MODALIDA
            INTO
            :APOLICE-RAMO,
            :APOLICE-MODALIDA
            FROM
            SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO
							,
											MODALIDA
											FROM
											SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'";

            return query;
        }
        public string APOLICE_RAMO { get; set; }
        public string APOLICE_MODALIDA { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }

        public static M_300_150_240_COBERTURAS_DB_SELECT_2_Query1 Execute(M_300_150_240_COBERTURAS_DB_SELECT_2_Query1 m_300_150_240_COBERTURAS_DB_SELECT_2_Query1)
        {
            var ths = m_300_150_240_COBERTURAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_300_150_240_COBERTURAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_300_150_240_COBERTURAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.APOLICE_RAMO = result[i++].Value?.ToString();
            dta.APOLICE_MODALIDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}