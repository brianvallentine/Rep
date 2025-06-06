using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 : QueryBasis<R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA,
            COD_BANCO ,
            TIPO_MOVTO_CC,
            COD_PRODUTO ,
            COD_CONVENIO ,
            NSAS ,
            COD_AGENCIA_SASS,
            OPER_CONTA_SASS,
            NUM_CONTA_SASS ,
            DIG_CONTA_SASS ,
            DATA_MOVIMENTO ,
            DATA_PROXIMO_DEB,
            DIA_DEBITO ,
            SIT_REGISTRO ,
            TIMESTAMP ,
            DESCR_CONVENIO
            INTO :PARAMCON-COD-EMPRESA,
            :PARAMCON-COD-BANCO,
            :PARAMCON-TIPO-MOVTO-CC,
            :PARAMCON-COD-PRODUTO ,
            :PARAMCON-COD-CONVENIO ,
            :PARAMCON-NSAS ,
            :PARAMCON-COD-AGENCIA-SASS,
            :PARAMCON-OPER-CONTA-SASS,
            :PARAMCON-NUM-CONTA-SASS,
            :PARAMCON-DIG-CONTA-SASS,
            :PARAMCON-DATA-MOVIMENTO,
            :PARAMCON-DATA-PROXIMO-DEB,
            :PARAMCON-DIA-DEBITO ,
            :PARAMCON-SIT-REGISTRO,
            :PARAMCON-TIMESTAMP ,
            :PARAMCON-DESCR-CONVENIO
            FROM SEGUROS.PARAM_CONTACEF
            WHERE COD_CONVENIO = 43350
            AND SIT_REGISTRO = 'A'
            AND TIPO_MOVTO_CC = 1
            AND COD_PRODUTO IN (
            SELECT VALUE(MAX(COD_PRODUTO),0)
            FROM SEGUROS.PARAM_CONTACEF
            WHERE COD_CONVENIO = 43350
            AND SIT_REGISTRO = 'A' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA
							,
											COD_BANCO 
							,
											TIPO_MOVTO_CC
							,
											COD_PRODUTO 
							,
											COD_CONVENIO 
							,
											NSAS 
							,
											COD_AGENCIA_SASS
							,
											OPER_CONTA_SASS
							,
											NUM_CONTA_SASS 
							,
											DIG_CONTA_SASS 
							,
											DATA_MOVIMENTO 
							,
											DATA_PROXIMO_DEB
							,
											DIA_DEBITO 
							,
											SIT_REGISTRO 
							,
											TIMESTAMP 
							,
											DESCR_CONVENIO
											FROM SEGUROS.PARAM_CONTACEF
											WHERE COD_CONVENIO = 43350
											AND SIT_REGISTRO = 'A'
											AND TIPO_MOVTO_CC = 1
											AND COD_PRODUTO IN (
											SELECT VALUE(MAX(COD_PRODUTO)
							,0)
											FROM SEGUROS.PARAM_CONTACEF
											WHERE COD_CONVENIO = 43350
											AND SIT_REGISTRO = 'A' )
											WITH UR";

            return query;
        }
        public string PARAMCON_COD_EMPRESA { get; set; }
        public string PARAMCON_COD_BANCO { get; set; }
        public string PARAMCON_TIPO_MOVTO_CC { get; set; }
        public string PARAMCON_COD_PRODUTO { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_NSAS { get; set; }
        public string PARAMCON_COD_AGENCIA_SASS { get; set; }
        public string PARAMCON_OPER_CONTA_SASS { get; set; }
        public string PARAMCON_NUM_CONTA_SASS { get; set; }
        public string PARAMCON_DIG_CONTA_SASS { get; set; }
        public string PARAMCON_DATA_MOVIMENTO { get; set; }
        public string PARAMCON_DATA_PROXIMO_DEB { get; set; }
        public string PARAMCON_DIA_DEBITO { get; set; }
        public string PARAMCON_SIT_REGISTRO { get; set; }
        public string PARAMCON_TIMESTAMP { get; set; }
        public string PARAMCON_DESCR_CONVENIO { get; set; }

        public static R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 Execute(R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 r3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1)
        {
            var ths = r3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMCON_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PARAMCON_COD_BANCO = result[i++].Value?.ToString();
            dta.PARAMCON_TIPO_MOVTO_CC = result[i++].Value?.ToString();
            dta.PARAMCON_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PARAMCON_COD_CONVENIO = result[i++].Value?.ToString();
            dta.PARAMCON_NSAS = result[i++].Value?.ToString();
            dta.PARAMCON_COD_AGENCIA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_OPER_CONTA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_NUM_CONTA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_DIG_CONTA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PARAMCON_DATA_PROXIMO_DEB = result[i++].Value?.ToString();
            dta.PARAMCON_DIA_DEBITO = result[i++].Value?.ToString();
            dta.PARAMCON_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PARAMCON_TIMESTAMP = result[i++].Value?.ToString();
            dta.PARAMCON_DESCR_CONVENIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}