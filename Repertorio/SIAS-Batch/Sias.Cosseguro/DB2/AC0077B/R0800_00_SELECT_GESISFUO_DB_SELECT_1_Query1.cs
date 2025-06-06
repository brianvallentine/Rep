using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1 : QueryBasis<R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDE_SISTEMA,
            COD_FUNCAO,
            IDE_SISTEMA_OPER,
            NUM_FATOR
            INTO :GESISFUO-IDE-SISTEMA,
            :GESISFUO-COD-FUNCAO,
            :GESISFUO-IDE-SISTEMA-OPER,
            :GESISFUO-NUM-FATOR
            FROM SEGUROS.GE_SIS_FUNCAO_OPER
            WHERE IDE_SISTEMA = 'SI'
            AND COD_FUNCAO IN (02,05,06,08,12,15,
            16,17,18,20,21,22,
            24,25,26,34)
            AND IDE_SISTEMA_OPER = IDE_SISTEMA
            AND COD_OPERACAO = :V1HSIN-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IDE_SISTEMA
							,
											COD_FUNCAO
							,
											IDE_SISTEMA_OPER
							,
											NUM_FATOR
											FROM SEGUROS.GE_SIS_FUNCAO_OPER
											WHERE IDE_SISTEMA = 'SI'
											AND COD_FUNCAO IN (02
							,05
							,06
							,08
							,12
							,15
							,
											16
							,17
							,18
							,20
							,21
							,22
							,
											24
							,25
							,26
							,34)
											AND IDE_SISTEMA_OPER = IDE_SISTEMA
											AND COD_OPERACAO = '{this.V1HSIN_OPERACAO}'";

            return query;
        }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_NUM_FATOR { get; set; }
        public string V1HSIN_OPERACAO { get; set; }

        public static R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1 Execute(R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1 r0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISFUO_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GESISFUO_COD_FUNCAO = result[i++].Value?.ToString();
            dta.GESISFUO_IDE_SISTEMA_OPER = result[i++].Value?.ToString();
            dta.GESISFUO_NUM_FATOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}