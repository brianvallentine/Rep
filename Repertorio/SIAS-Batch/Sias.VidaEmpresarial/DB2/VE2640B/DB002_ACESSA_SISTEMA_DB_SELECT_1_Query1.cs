using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            INTO :SISTEMAS-DATA-MOV-ABERTO
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = '{this.SISTEMAS_IDE_SISTEMA}'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_IDE_SISTEMA { get; set; }

        public static DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1 Execute(DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1 dB002_ACESSA_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = dB002_ACESSA_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB002_ACESSA_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}