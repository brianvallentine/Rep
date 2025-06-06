using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1706B
{
    public class M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1 : QueryBasis<M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            TIPO_APOLICE
            INTO
            :APOLICES-TIPO-APOLICE
            FROM
            SEGUROS.APOLICES
            WHERE
            NUM_APOLICE = :APOLICES-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											TIPO_APOLICE
											FROM
											SEGUROS.APOLICES
											WHERE
											NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_TIPO_APOLICE { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1 Execute(M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1 m_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1)
        {
            var ths = m_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_TIPO_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}