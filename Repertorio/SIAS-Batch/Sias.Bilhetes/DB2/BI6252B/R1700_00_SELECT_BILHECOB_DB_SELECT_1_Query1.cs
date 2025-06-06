using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_MOEDA ,
            A.PCT_COM_CORRETOR ,
            A.IMP_SEGURADA_IX ,
            A.PRM_TARIFARIO_IX ,
            A.PRM_TOTAL ,
            A.PCT_IOCC ,
            B.PCT_IOCC_RAMO ,
            (B.PCT_IOCC_RAMO / 100)
            INTO :BILHECOB-COD-MOEDA ,
            :BILHECOB-PCT-COM-CORRETOR ,
            :BILHECOB-IMP-SEGURADA-IX ,
            :BILHECOB-PRM-TARIFARIO-IX ,
            :BILHECOB-PRM-TOTAL:VIND-NULL01 ,
            :BILHECOB-PCT-IOCC:VIND-NULL02 ,
            :RAMOCOMP-PCT-IOCC-RAMO ,
            :WSHOST-PCT-IOCC
            FROM SEGUROS.BILHETE_COBERTURA A,
            SEGUROS.RAMO_COMPLEMENTAR B
            WHERE A.RAMO_COBERTURA =
            :BILHECOB-RAMO-COBERTURA
            AND A.MODALI_COBERTURA =
            :BILHECOB-MODALI-COBERTURA
            AND A.COD_OPCAO_PLANO =
            :BILHECOB-COD-OPCAO-PLANO
            AND A.COD_PRODUTO =
            :BILHECOB-COD-PRODUTO
            AND A.DATA_INIVIGENCIA <=
            :BILHECOB-DATA-INIVIGENCIA
            AND A.DATA_TERVIGENCIA >=
            :BILHECOB-DATA-TERVIGENCIA
            AND A.IDE_COBERTURA =
            :BILHECOB-IDE-COBERTURA
            AND B.RAMO_EMISSOR =
            A.RAMO_COBERTURA
            AND B.DATA_INIVIGENCIA <=
            :BILHECOB-DATA-INIVIGENCIA
            AND B.DATA_TERVIGENCIA >=
            :BILHECOB-DATA-TERVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_MOEDA 
							,
											A.PCT_COM_CORRETOR 
							,
											A.IMP_SEGURADA_IX 
							,
											A.PRM_TARIFARIO_IX 
							,
											A.PRM_TOTAL 
							,
											A.PCT_IOCC 
							,
											B.PCT_IOCC_RAMO 
							,
											(B.PCT_IOCC_RAMO / 100)
											FROM SEGUROS.BILHETE_COBERTURA A
							,
											SEGUROS.RAMO_COMPLEMENTAR B
											WHERE A.RAMO_COBERTURA =
											'{this.BILHECOB_RAMO_COBERTURA}'
											AND A.MODALI_COBERTURA =
											'{this.BILHECOB_MODALI_COBERTURA}'
											AND A.COD_OPCAO_PLANO =
											'{this.BILHECOB_COD_OPCAO_PLANO}'
											AND A.COD_PRODUTO =
											'{this.BILHECOB_COD_PRODUTO}'
											AND A.DATA_INIVIGENCIA <=
											'{this.BILHECOB_DATA_INIVIGENCIA}'
											AND A.DATA_TERVIGENCIA >=
											'{this.BILHECOB_DATA_TERVIGENCIA}'
											AND A.IDE_COBERTURA =
											'{this.BILHECOB_IDE_COBERTURA}'
											AND B.RAMO_EMISSOR =
											A.RAMO_COBERTURA
											AND B.DATA_INIVIGENCIA <=
											'{this.BILHECOB_DATA_INIVIGENCIA}'
											AND B.DATA_TERVIGENCIA >=
											'{this.BILHECOB_DATA_TERVIGENCIA}'
											WITH UR";

            return query;
        }
        public string BILHECOB_COD_MOEDA { get; set; }
        public string BILHECOB_PCT_COM_CORRETOR { get; set; }
        public string BILHECOB_IMP_SEGURADA_IX { get; set; }
        public string BILHECOB_PRM_TARIFARIO_IX { get; set; }
        public string BILHECOB_PRM_TOTAL { get; set; }
        public string VIND_NULL01 { get; set; }
        public string BILHECOB_PCT_IOCC { get; set; }
        public string VIND_NULL02 { get; set; }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string WSHOST_PCT_IOCC { get; set; }
        public string BILHECOB_MODALI_COBERTURA { get; set; }
        public string BILHECOB_DATA_INIVIGENCIA { get; set; }
        public string BILHECOB_DATA_TERVIGENCIA { get; set; }
        public string BILHECOB_COD_OPCAO_PLANO { get; set; }
        public string BILHECOB_RAMO_COBERTURA { get; set; }
        public string BILHECOB_IDE_COBERTURA { get; set; }
        public string BILHECOB_COD_PRODUTO { get; set; }

        public static R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1 r1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHECOB_COD_MOEDA = result[i++].Value?.ToString();
            dta.BILHECOB_PCT_COM_CORRETOR = result[i++].Value?.ToString();
            dta.BILHECOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.BILHECOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.BILHECOB_PRM_TOTAL = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.BILHECOB_PRM_TOTAL) ? "-1" : "0";
            dta.BILHECOB_PCT_IOCC = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.BILHECOB_PCT_IOCC) ? "-1" : "0";
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            dta.WSHOST_PCT_IOCC = result[i++].Value?.ToString();
            return dta;
        }

    }
}