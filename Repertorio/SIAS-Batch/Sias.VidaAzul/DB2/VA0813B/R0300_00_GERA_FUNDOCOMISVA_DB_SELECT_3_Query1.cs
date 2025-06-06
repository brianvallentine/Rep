using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1 : QueryBasis<R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TERMO,
            COD_AGENCIA_OP,
            NUM_MATRICULA_VEN
            INTO :TERMOADE-NUM-TERMO,
            :TERMOADE-COD-AGENCIA-OP,
            :TERMOADE-NUM-MATRICULA-VEN
            FROM SEGUROS.TERMO_ADESAO
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = :V0PROP-CODSUBES
            ORDER BY NUM_TERMO DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TERMO
							,
											COD_AGENCIA_OP
							,
											NUM_MATRICULA_VEN
											FROM SEGUROS.TERMO_ADESAO
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'
											ORDER BY NUM_TERMO DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_COD_AGENCIA_OP { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1 Execute(R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1 r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1)
        {
            var ths = r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1();
            var i = 0;
            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_OP = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_VEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}