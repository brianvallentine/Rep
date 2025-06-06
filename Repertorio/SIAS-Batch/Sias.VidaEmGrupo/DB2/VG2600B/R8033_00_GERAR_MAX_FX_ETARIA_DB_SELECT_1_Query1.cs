using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1 : QueryBasis<R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(FAIXA), 0) + 1
            INTO :FAIXAETA-FAIXA
            FROM SEGUROS.FAIXA_ETARIA
            WHERE NUM_APOLICE = :FAIXAETA-NUM-APOLICE
            AND COD_SUBGRUPO = :FAIXAETA-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(FAIXA)
							, 0) + 1
											FROM SEGUROS.FAIXA_ETARIA
											WHERE NUM_APOLICE = '{this.FAIXAETA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.FAIXAETA_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string FAIXAETA_FAIXA { get; set; }
        public string FAIXAETA_COD_SUBGRUPO { get; set; }
        public string FAIXAETA_NUM_APOLICE { get; set; }

        public static R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1 Execute(R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1 r8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1)
        {
            var ths = r8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.FAIXAETA_FAIXA = result[i++].Value?.ToString();
            return dta;
        }

    }
}