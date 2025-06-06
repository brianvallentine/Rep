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
    public class M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 : QueryBasis<M_300_150_240_COBERTURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            RAMO
            INTO
            :APOLICE-RAMO
            FROM
            SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :RELAT-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO
											FROM
											SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.RELAT_NUM_APOLICE}'";

            return query;
        }
        public string APOLICE_RAMO { get; set; }
        public string RELAT_NUM_APOLICE { get; set; }

        public static M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 Execute(M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 m_300_150_240_COBERTURAS_DB_SELECT_1_Query1)
        {
            var ths = m_300_150_240_COBERTURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_300_150_240_COBERTURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICE_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}