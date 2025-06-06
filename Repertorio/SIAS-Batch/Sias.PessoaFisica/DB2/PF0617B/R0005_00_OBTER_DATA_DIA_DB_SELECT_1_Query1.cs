using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 : QueryBasis<R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            DATA_MOV_ABERTO
            INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :WHOST-DATA-REF-M1YEAR
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = '{this.SISTEMAS_IDE_SISTEMA}'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_DATA_REF_M1YEAR { get; set; }
        public string SISTEMAS_IDE_SISTEMA { get; set; }

        public static R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 Execute(R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1)
        {
            var ths = r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.WHOST_DATA_REF_M1YEAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}