using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1 : QueryBasis<R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(E.VAL_COBERTURA_IX)
            INTO :WS002-VAL-COB-IX:VIND-ACUM-RISCO
            FROM SEGUROS.CLIENTES A
            , SEGUROS.BILHETE B
            , SEGUROS.ENDOSSOS C
            , SEGUROS.CONVERSAO_SICOB D
            , SEGUROS.BILHETE_COBERTURA E
            WHERE A.CGCCPF = :V0CLIE-CGCCPF
            AND B.COD_CLIENTE = A.COD_CLIENTE
            AND B.SITUACAO = '9'
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.NUM_ENDOSSO = 0
            AND C.DATA_TERVIGENCIA > CURRENT DATE
            AND D.NUM_SICOB = B.NUM_BILHETE
            AND E.RAMO_COBERTURA = B.RAMO
            AND E.COD_PRODUTO = C.COD_PRODUTO
            AND E.COD_OPCAO_PLANO = B.OPC_COBERTURA
            AND E.DATA_INIVIGENCIA <= B.DATA_VENDA
            AND E.DATA_TERVIGENCIA >= B.DATA_VENDA
            AND C.COD_PRODUTO IN (8144, 8145, 8146, 8147,
            8148, 8149, 8150,
            :JVPRD8144, :JVPRD8145,
            :JVPRD8146, :JVPRD8147,
            :JVPRD8148, :JVPRD8149, :JVPRD8150)
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SUM(E.VAL_COBERTURA_IX)
											FROM SEGUROS.CLIENTES A
											, SEGUROS.BILHETE B
											, SEGUROS.ENDOSSOS C
											, SEGUROS.CONVERSAO_SICOB D
											, SEGUROS.BILHETE_COBERTURA E
											WHERE A.CGCCPF = '{this.V0CLIE_CGCCPF}'
											AND B.COD_CLIENTE = A.COD_CLIENTE
											AND B.SITUACAO = '9'
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.NUM_ENDOSSO = 0
											AND C.DATA_TERVIGENCIA > CURRENT DATE
											AND D.NUM_SICOB = B.NUM_BILHETE
											AND E.RAMO_COBERTURA = B.RAMO
											AND E.COD_PRODUTO = C.COD_PRODUTO
											AND E.COD_OPCAO_PLANO = B.OPC_COBERTURA
											AND E.DATA_INIVIGENCIA <= B.DATA_VENDA
											AND E.DATA_TERVIGENCIA >= B.DATA_VENDA
											AND C.COD_PRODUTO IN (8144
							, 8145
							, 8146
							, 8147
							,
											8148
							, 8149
							, 8150
							,
											'{this.JVPRD8144}'
							, '{this.JVPRD8145}'
							,
											'{this.JVPRD8146}'
							, '{this.JVPRD8147}'
							,
											'{this.JVPRD8148}'
							, '{this.JVPRD8149}'
							, '{this.JVPRD8150}')
											WITH UR";

            return query;
        }
        public string WS002_VAL_COB_IX { get; set; }
        public string VIND_ACUM_RISCO { get; set; }
        public string V0CLIE_CGCCPF { get; set; }
        public string JVPRD8144 { get; set; }
        public string JVPRD8145 { get; set; }
        public string JVPRD8146 { get; set; }
        public string JVPRD8147 { get; set; }
        public string JVPRD8148 { get; set; }
        public string JVPRD8149 { get; set; }
        public string JVPRD8150 { get; set; }

        public static R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1 Execute(R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1 r3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1)
        {
            var ths = r3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1();
            var i = 0;
            dta.WS002_VAL_COB_IX = result[i++].Value?.ToString();
            dta.VIND_ACUM_RISCO = string.IsNullOrWhiteSpace(dta.WS002_VAL_COB_IX) ? "-1" : "0";
            return dta;
        }

    }
}