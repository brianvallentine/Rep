using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0817B
{
    public class M_0100_PROCESSA_DB_SELECT_5_Query1 : QueryBasis<M_0100_PROCESSA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            PERI_INICIAL
            INTO
            :V0RELA-PERI-INICIAL
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'VG9574B'
            AND NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND CODSUBES = :V0PROP-CODSUBES
            AND PERI_INICIAL = :V0RELA-PERI-INICIAL
            AND PERI_FINAL = :V0RELA-PERI-FINAL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PERI_INICIAL
											FROM SEGUROS.V0RELATORIOS
											WHERE CODRELAT = 'VG9574B'
											AND NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND CODSUBES = '{this.V0PROP_CODSUBES}'
											AND PERI_INICIAL = '{this.V0RELA_PERI_INICIAL}'
											AND PERI_FINAL = '{this.V0RELA_PERI_FINAL}'";

            return query;
        }
        public string V0RELA_PERI_INICIAL { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0RELA_PERI_FINAL { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static M_0100_PROCESSA_DB_SELECT_5_Query1 Execute(M_0100_PROCESSA_DB_SELECT_5_Query1 m_0100_PROCESSA_DB_SELECT_5_Query1)
        {
            var ths = m_0100_PROCESSA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0RELA_PERI_INICIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}