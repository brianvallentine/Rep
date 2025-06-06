using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1 : QueryBasis<R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLR_MENSALIDADE
            INTO :FCTITULO-VLR-MENSALIDADE
            FROM FDRCAP.FC_TITULO
            WHERE NUM_PROPOSTA = :FCTITULO-NUM-PROPOSTA
            AND NUM_PLANO = 810
            AND COD_STA_TITULO = 'ATV'
            ORDER BY DTH_ATIVACAO DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLR_MENSALIDADE
											FROM FDRCAP.FC_TITULO
											WHERE NUM_PROPOSTA = '{this.FCTITULO_NUM_PROPOSTA}'
											AND NUM_PLANO = 810
											AND COD_STA_TITULO = 'ATV'
											ORDER BY DTH_ATIVACAO DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string FCTITULO_VLR_MENSALIDADE { get; set; }
        public string FCTITULO_NUM_PROPOSTA { get; set; }

        public static R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1 Execute(R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1 r1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1)
        {
            var ths = r1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1052_00_PEGAR_VLR_TITULO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FCTITULO_VLR_MENSALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}