using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1 : QueryBasis<R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.CONTROL_DESPES_CEF
            (COD_EMPRESA,
            ANO_REFERENCIA,
            MES_REFERENCIA,
            BCO_AVISO,
            AGE_AVISO,
            NUM_AVISO_CREDITO,
            COD_PRODUTO,
            TIPO_REGISTRO,
            SITUACAO,
            TIPO_COBRANCA,
            DATA_MOVIMENTO,
            DATA_AVISO,
            QTD_REGISTROS,
            PRM_TOTAL,
            PRM_LIQUIDO,
            VAL_TARIFA,
            VAL_BALCAO,
            VAL_IOCC,
            VAL_DESCONTO,
            VAL_JUROS,
            VAL_MULTA,
            TIMESTAMP)
            VALUES (:V0DPCF-CODEMP ,
            :V0DPCF-ANOREF ,
            :V0DPCF-MESREF ,
            :V0DPCF-BCOAVISO ,
            :V0DPCF-AGEAVISO ,
            :V0DPCF-NRAVISO ,
            :V0DPCF-CODPRODU ,
            :V0DPCF-TIPOREG ,
            :V0DPCF-SITUACAO ,
            :V0DPCF-TIPOCOB ,
            :V0DPCF-DTMOVTO ,
            :V0DPCF-DTAVISO ,
            :V0DPCF-QTDREG ,
            :V0DPCF-VLPRMTOT ,
            :V0DPCF-VLPRMLIQ ,
            :V0DPCF-VLTARIFA ,
            :V0DPCF-VLBALCAO ,
            :V0DPCF-VLIOCC ,
            :V0DPCF-VLDESCON ,
            :V0DPCF-VLJUROS ,
            :V0DPCF-VLMULTA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA, ANO_REFERENCIA, MES_REFERENCIA, BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, COD_PRODUTO, TIPO_REGISTRO, SITUACAO, TIPO_COBRANCA, DATA_MOVIMENTO, DATA_AVISO, QTD_REGISTROS, PRM_TOTAL, PRM_LIQUIDO, VAL_TARIFA, VAL_BALCAO, VAL_IOCC, VAL_DESCONTO, VAL_JUROS, VAL_MULTA, TIMESTAMP) VALUES ({FieldThreatment(this.V0DPCF_CODEMP)} , {FieldThreatment(this.V0DPCF_ANOREF)} , {FieldThreatment(this.V0DPCF_MESREF)} , {FieldThreatment(this.V0DPCF_BCOAVISO)} , {FieldThreatment(this.V0DPCF_AGEAVISO)} , {FieldThreatment(this.V0DPCF_NRAVISO)} , {FieldThreatment(this.V0DPCF_CODPRODU)} , {FieldThreatment(this.V0DPCF_TIPOREG)} , {FieldThreatment(this.V0DPCF_SITUACAO)} , {FieldThreatment(this.V0DPCF_TIPOCOB)} , {FieldThreatment(this.V0DPCF_DTMOVTO)} , {FieldThreatment(this.V0DPCF_DTAVISO)} , {FieldThreatment(this.V0DPCF_QTDREG)} , {FieldThreatment(this.V0DPCF_VLPRMTOT)} , {FieldThreatment(this.V0DPCF_VLPRMLIQ)} , {FieldThreatment(this.V0DPCF_VLTARIFA)} , {FieldThreatment(this.V0DPCF_VLBALCAO)} , {FieldThreatment(this.V0DPCF_VLIOCC)} , {FieldThreatment(this.V0DPCF_VLDESCON)} , {FieldThreatment(this.V0DPCF_VLJUROS)} , {FieldThreatment(this.V0DPCF_VLMULTA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0DPCF_CODEMP { get; set; }
        public string V0DPCF_ANOREF { get; set; }
        public string V0DPCF_MESREF { get; set; }
        public string V0DPCF_BCOAVISO { get; set; }
        public string V0DPCF_AGEAVISO { get; set; }
        public string V0DPCF_NRAVISO { get; set; }
        public string V0DPCF_CODPRODU { get; set; }
        public string V0DPCF_TIPOREG { get; set; }
        public string V0DPCF_SITUACAO { get; set; }
        public string V0DPCF_TIPOCOB { get; set; }
        public string V0DPCF_DTMOVTO { get; set; }
        public string V0DPCF_DTAVISO { get; set; }
        public string V0DPCF_QTDREG { get; set; }
        public string V0DPCF_VLPRMTOT { get; set; }
        public string V0DPCF_VLPRMLIQ { get; set; }
        public string V0DPCF_VLTARIFA { get; set; }
        public string V0DPCF_VLBALCAO { get; set; }
        public string V0DPCF_VLIOCC { get; set; }
        public string V0DPCF_VLDESCON { get; set; }
        public string V0DPCF_VLJUROS { get; set; }
        public string V0DPCF_VLMULTA { get; set; }

        public static void Execute(R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1 r8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1)
        {
            var ths = r8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}