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
    public class R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1 : QueryBasis<R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IFNULL(COUNT(*),0)
            INTO :WS-COUNT
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'VA0469B'
            AND COD_USUARIO = :RELATORI-COD-USUARIO
            AND DATA_SOLICITACAO = :RELATORI-DATA-SOLICITACAO
            AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA
            AND NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_ORDEM = :RELATORI-NUM-ORDEM
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IFNULL(COUNT(*)
							,0)
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO = 'VA0469B'
											AND COD_USUARIO = '{this.RELATORI_COD_USUARIO}'
											AND DATA_SOLICITACAO = '{this.RELATORI_DATA_SOLICITACAO}'
											AND IDE_SISTEMA = '{this.RELATORI_IDE_SISTEMA}'
											AND NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_ORDEM = '{this.RELATORI_NUM_ORDEM}'
											WITH UR";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }
        public string RELATORI_NUM_ORDEM { get; set; }

        public static R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1 Execute(R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1 r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1)
        {
            var ths = r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}