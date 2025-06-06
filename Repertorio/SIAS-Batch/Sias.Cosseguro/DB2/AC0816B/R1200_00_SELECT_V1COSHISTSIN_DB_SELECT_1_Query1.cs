using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DTMOVTO
            INTO :WHOST-DTMOVTO
            FROM SEGUROS.V1COSSEG_HISTSIN A,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE A.CONGENER = :V1CHSI-CONGENER
            AND A.NUM_SINISTRO = :V1CHSI-NUM-SINI
            AND A.OCORHIST = :V1CHSI-OCORHIST
            AND B.IDE_SISTEMA = 'SI'
            AND B.COD_FUNCAO = :GESISORL-COD-FUNCAO
            AND B.IDE_SISTEMA_OPER = 'SI'
            AND B.COD_OPERACAO = A.OPERACAO
            AND B.NUM_FATOR = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.DTMOVTO
											FROM SEGUROS.V1COSSEG_HISTSIN A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE A.CONGENER = '{this.V1CHSI_CONGENER}'
											AND A.NUM_SINISTRO = '{this.V1CHSI_NUM_SINI}'
											AND A.OCORHIST = '{this.V1CHSI_OCORHIST}'
											AND B.IDE_SISTEMA = 'SI'
											AND B.COD_FUNCAO = '{this.GESISORL_COD_FUNCAO}'
											AND B.IDE_SISTEMA_OPER = 'SI'
											AND B.COD_OPERACAO = A.OPERACAO
											AND B.NUM_FATOR = 1";

            return query;
        }
        public string WHOST_DTMOVTO { get; set; }
        public string GESISORL_COD_FUNCAO { get; set; }
        public string V1CHSI_CONGENER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V1CHSI_OCORHIST { get; set; }

        public static R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 r1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTMOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}