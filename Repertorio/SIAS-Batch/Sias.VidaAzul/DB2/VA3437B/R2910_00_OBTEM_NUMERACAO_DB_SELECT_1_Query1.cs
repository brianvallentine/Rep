using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 : QueryBasis<R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_COPIAS)
            INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'CARTAECT'
            AND MES_REFERENCIA = :V1SIST-MESREFER
            AND ANO_REFERENCIA = :V1SIST-ANOREFER
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_COPIAS)
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO = 'CARTAECT'
											AND MES_REFERENCIA = '{this.V1SIST_MESREFER}'
											AND ANO_REFERENCIA = '{this.V1SIST_ANOREFER}'
											WITH UR";

            return query;
        }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string VIND_NRCOPIAS { get; set; }
        public string V1SIST_MESREFER { get; set; }
        public string V1SIST_ANOREFER { get; set; }

        public static R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 Execute(R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1)
        {
            var ths = r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_NUM_COPIAS = result[i++].Value?.ToString();
            dta.VIND_NRCOPIAS = string.IsNullOrWhiteSpace(dta.RELATORI_NUM_COPIAS) ? "-1" : "0";
            return dta;
        }

    }
}