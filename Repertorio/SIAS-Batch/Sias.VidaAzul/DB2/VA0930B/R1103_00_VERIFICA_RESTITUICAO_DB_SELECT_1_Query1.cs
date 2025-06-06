using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 : QueryBasis<R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_DEVOLUCAO,
            DESC_DEVOLUCAO
            INTO :DEVOLVID-COD-DEVOLUCAO,
            :DEVOLVID-DESC-DEVOLUCAO
            FROM SEGUROS.DEVOLUCAO_VIDAZUL
            WHERE COD_DEVOLUCAO = :RELATORI-COD-OPERACAO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_DEVOLUCAO
							,
											DESC_DEVOLUCAO
											FROM SEGUROS.DEVOLUCAO_VIDAZUL
											WHERE COD_DEVOLUCAO = '{this.RELATORI_COD_OPERACAO}'
											WITH UR";

            return query;
        }
        public string DEVOLVID_COD_DEVOLUCAO { get; set; }
        public string DEVOLVID_DESC_DEVOLUCAO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }

        public static R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 Execute(R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1)
        {
            var ths = r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.DEVOLVID_COD_DEVOLUCAO = result[i++].Value?.ToString();
            dta.DEVOLVID_DESC_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}