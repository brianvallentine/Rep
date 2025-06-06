using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1 : QueryBasis<R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PARAM_CONTACEF
            ( COD_EMPRESA,
            COD_BANCO ,
            TIPO_MOVTO_CC,
            COD_PRODUTO ,
            COD_CONVENIO ,
            NSAS ,
            COD_AGENCIA_SASS,
            OPER_CONTA_SASS,
            NUM_CONTA_SASS,
            DIG_CONTA_SASS,
            DATA_MOVIMENTO,
            DATA_PROXIMO_DEB,
            DIA_DEBITO ,
            SIT_REGISTRO ,
            TIMESTAMP ,
            DESCR_CONVENIO )
            VALUES ( 0,
            104,
            1,
            1,
            43350,
            0,
            0630,
            003,
            255,
            0,
            :SISTEMAS-DATA-MOV-ABERTO,
            '9999-12-31' ,
            0,
            'A' ,
            CURRENT TIMESTAMP,
            'SIACC - CONV. PGTO CAIXA' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARAM_CONTACEF ( COD_EMPRESA, COD_BANCO , TIPO_MOVTO_CC, COD_PRODUTO , COD_CONVENIO , NSAS , COD_AGENCIA_SASS, OPER_CONTA_SASS, NUM_CONTA_SASS, DIG_CONTA_SASS, DATA_MOVIMENTO, DATA_PROXIMO_DEB, DIA_DEBITO , SIT_REGISTRO , TIMESTAMP , DESCR_CONVENIO ) VALUES ( 0, 104, 1, 1, 43350, 0, 0630, 003, 255, 0, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, '9999-12-31' , 0, 'A' , CURRENT TIMESTAMP, 'SIACC - CONV. PGTO CAIXA' )";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1 r0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1)
        {
            var ths = r0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}