using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 : QueryBasis<R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.CONTROL_DESPES_CEF
            ( COD_EMPRESA
            , ANO_REFERENCIA
            , MES_REFERENCIA
            , BCO_AVISO
            , AGE_AVISO
            , NUM_AVISO_CREDITO
            , COD_PRODUTO
            , TIPO_REGISTRO
            , SITUACAO
            , TIPO_COBRANCA
            , DATA_MOVIMENTO
            , DATA_AVISO
            , QTD_REGISTROS
            , PRM_TOTAL
            , PRM_LIQUIDO
            , VAL_TARIFA
            , VAL_BALCAO
            , VAL_IOCC
            , VAL_DESCONTO
            , VAL_JUROS
            , VAL_MULTA
            , TIMESTAMP
            )
            VALUES
            ( :CONDESCE-COD-EMPRESA
            , :CONDESCE-ANO-REFERENCIA
            , :CONDESCE-MES-REFERENCIA
            , :CONDESCE-BCO-AVISO
            , :CONDESCE-AGE-AVISO
            , :CONDESCE-NUM-AVISO-CREDITO
            , :CONDESCE-COD-PRODUTO
            , :CONDESCE-TIPO-REGISTRO
            , :CONDESCE-SITUACAO
            , :CONDESCE-TIPO-COBRANCA
            , :CONDESCE-DATA-MOVIMENTO
            , :CONDESCE-DATA-AVISO
            , :CONDESCE-QTD-REGISTROS
            , :CONDESCE-PRM-TOTAL
            , :CONDESCE-PRM-LIQUIDO
            , :CONDESCE-VAL-TARIFA
            , :CONDESCE-VAL-BALCAO
            , :CONDESCE-VAL-IOCC
            , :CONDESCE-VAL-DESCONTO
            , :CONDESCE-VAL-JUROS
            , :CONDESCE-VAL-MULTA
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONTROL_DESPES_CEF ( COD_EMPRESA , ANO_REFERENCIA , MES_REFERENCIA , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_PRODUTO , TIPO_REGISTRO , SITUACAO , TIPO_COBRANCA , DATA_MOVIMENTO , DATA_AVISO , QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA , TIMESTAMP ) VALUES ( {FieldThreatment(this.CONDESCE_COD_EMPRESA)} , {FieldThreatment(this.CONDESCE_ANO_REFERENCIA)} , {FieldThreatment(this.CONDESCE_MES_REFERENCIA)} , {FieldThreatment(this.CONDESCE_BCO_AVISO)} , {FieldThreatment(this.CONDESCE_AGE_AVISO)} , {FieldThreatment(this.CONDESCE_NUM_AVISO_CREDITO)} , {FieldThreatment(this.CONDESCE_COD_PRODUTO)} , {FieldThreatment(this.CONDESCE_TIPO_REGISTRO)} , {FieldThreatment(this.CONDESCE_SITUACAO)} , {FieldThreatment(this.CONDESCE_TIPO_COBRANCA)} , {FieldThreatment(this.CONDESCE_DATA_MOVIMENTO)} , {FieldThreatment(this.CONDESCE_DATA_AVISO)} , {FieldThreatment(this.CONDESCE_QTD_REGISTROS)} , {FieldThreatment(this.CONDESCE_PRM_TOTAL)} , {FieldThreatment(this.CONDESCE_PRM_LIQUIDO)} , {FieldThreatment(this.CONDESCE_VAL_TARIFA)} , {FieldThreatment(this.CONDESCE_VAL_BALCAO)} , {FieldThreatment(this.CONDESCE_VAL_IOCC)} , {FieldThreatment(this.CONDESCE_VAL_DESCONTO)} , {FieldThreatment(this.CONDESCE_VAL_JUROS)} , {FieldThreatment(this.CONDESCE_VAL_MULTA)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string CONDESCE_COD_EMPRESA { get; set; }
        public string CONDESCE_ANO_REFERENCIA { get; set; }
        public string CONDESCE_MES_REFERENCIA { get; set; }
        public string CONDESCE_BCO_AVISO { get; set; }
        public string CONDESCE_AGE_AVISO { get; set; }
        public string CONDESCE_NUM_AVISO_CREDITO { get; set; }
        public string CONDESCE_COD_PRODUTO { get; set; }
        public string CONDESCE_TIPO_REGISTRO { get; set; }
        public string CONDESCE_SITUACAO { get; set; }
        public string CONDESCE_TIPO_COBRANCA { get; set; }
        public string CONDESCE_DATA_MOVIMENTO { get; set; }
        public string CONDESCE_DATA_AVISO { get; set; }
        public string CONDESCE_QTD_REGISTROS { get; set; }
        public string CONDESCE_PRM_TOTAL { get; set; }
        public string CONDESCE_PRM_LIQUIDO { get; set; }
        public string CONDESCE_VAL_TARIFA { get; set; }
        public string CONDESCE_VAL_BALCAO { get; set; }
        public string CONDESCE_VAL_IOCC { get; set; }
        public string CONDESCE_VAL_DESCONTO { get; set; }
        public string CONDESCE_VAL_JUROS { get; set; }
        public string CONDESCE_VAL_MULTA { get; set; }

        public static void Execute(R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 r3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1)
        {
            var ths = r3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}