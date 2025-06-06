using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1 : QueryBasis<R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_SOLICITACAO
            INTO :RELATORI-DATA-SOLICITACAO
            FROM SEGUROS.RELATORIOS
            WHERE COD_USUARIO = :RELATORI-COD-USUARIO
            AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_SOLICITACAO
											FROM SEGUROS.RELATORIOS
											WHERE COD_USUARIO = '{this.RELATORI_COD_USUARIO}'
											AND IDE_SISTEMA = '{this.RELATORI_IDE_SISTEMA}'
											WITH UR";

            return query;
        }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }

        public static R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1 Execute(R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1 r0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1)
        {
            var ths = r0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}