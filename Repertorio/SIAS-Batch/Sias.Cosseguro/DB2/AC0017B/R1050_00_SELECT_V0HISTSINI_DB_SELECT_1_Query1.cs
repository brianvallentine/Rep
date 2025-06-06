using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            A.DTMOVTO
            INTO :WHOST-DTMOVTO
            FROM SEGUROS.V0HISTSINI A,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE A.NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI
            AND A.OCORHIST = :V1HSIN-OCORHIST
            AND B.IDE_SISTEMA = :GESISFUO-IDE-SISTEMA
            AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO
            AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER
            AND B.COD_OPERACAO = A.OPERACAO
            AND B.NUM_FATOR = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											A.DTMOVTO
											FROM SEGUROS.V0HISTSINI A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE A.NUM_APOL_SINISTRO = '{this.V1MSIN_NUM_SINI}'
											AND A.OCORHIST = '{this.V1HSIN_OCORHIST}'
											AND B.IDE_SISTEMA = '{this.GESISFUO_IDE_SISTEMA}'
											AND B.COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND B.IDE_SISTEMA_OPER = '{this.GESISFUO_IDE_SISTEMA_OPER}'
											AND B.COD_OPERACAO = A.OPERACAO
											AND B.NUM_FATOR = 1";

            return query;
        }
        public string WHOST_DTMOVTO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }
        public string V1HSIN_OCORHIST { get; set; }

        public static R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 r1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTMOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}