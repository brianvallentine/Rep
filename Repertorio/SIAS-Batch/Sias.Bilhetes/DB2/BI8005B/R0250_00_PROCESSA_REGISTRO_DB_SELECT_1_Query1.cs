using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PG.COD_EMPRESA_CAP
            ,PD.COD_EMPRESA
            INTO :PARAMGER-COD-EMPRESA-CAP
            ,:PRODUTO-COD-EMPRESA
            FROM SEGUROS.PARAMETROS_GERAIS PG,
            SEGUROS.PRODUTO PD
            WHERE PG.COD_EMPRESA = PD.COD_EMPRESA
            AND PD.COD_PRODUTO = :V0ENDO-CODPRODU
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PG.COD_EMPRESA_CAP
											,PD.COD_EMPRESA
											FROM SEGUROS.PARAMETROS_GERAIS PG
							,
											SEGUROS.PRODUTO PD
											WHERE PG.COD_EMPRESA = PD.COD_EMPRESA
											AND PD.COD_PRODUTO = '{this.V0ENDO_CODPRODU}'";

            return query;
        }
        public string PARAMGER_COD_EMPRESA_CAP { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string V0ENDO_CODPRODU { get; set; }

        public static R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMGER_COD_EMPRESA_CAP = result[i++].Value?.ToString();
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}