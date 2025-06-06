using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0853B
{
    public class R0010_SELECT_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0010_SELECT_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATULT-PROCESSAMEN
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							, DATULT_PROCESSAMEN
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATULT_PROCESSAMEN { get; set; }

        public static R0010_SELECT_SISTEMA_DB_SELECT_1_Query1 Execute(R0010_SELECT_SISTEMA_DB_SELECT_1_Query1 r0010_SELECT_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0010_SELECT_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0010_SELECT_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0010_SELECT_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DATULT_PROCESSAMEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}