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
    public class R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            A.VAL_OPERACAO
            INTO :WHOST-VAL-OPER
            FROM SEGUROS.V1COSSEG_HISTSIN A,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE A.CONGENER = :V1APCD-CODCOSS
            AND A.NUM_SINISTRO = :V1MSIN-NUM-SINI
            AND A.OCORHIST = :V1HSIN-OCORHIST
            AND A.TIPSGU = :V0APOL-TIPSGU
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
											A.VAL_OPERACAO
											FROM SEGUROS.V1COSSEG_HISTSIN A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE A.CONGENER = '{this.V1APCD_CODCOSS}'
											AND A.NUM_SINISTRO = '{this.V1MSIN_NUM_SINI}'
											AND A.OCORHIST = '{this.V1HSIN_OCORHIST}'
											AND A.TIPSGU = '{this.V0APOL_TIPSGU}'
											AND B.IDE_SISTEMA = '{this.GESISFUO_IDE_SISTEMA}'
											AND B.COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND B.IDE_SISTEMA_OPER = '{this.GESISFUO_IDE_SISTEMA_OPER}'
											AND B.COD_OPERACAO = A.OPERACAO
											AND B.NUM_FATOR = 1";

            return query;
        }
        public string WHOST_VAL_OPER { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }
        public string V1HSIN_OCORHIST { get; set; }
        public string V1APCD_CODCOSS { get; set; }
        public string V0APOL_TIPSGU { get; set; }

        public static R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1 r1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_VAL_OPER = result[i++].Value?.ToString();
            return dta;
        }

    }
}