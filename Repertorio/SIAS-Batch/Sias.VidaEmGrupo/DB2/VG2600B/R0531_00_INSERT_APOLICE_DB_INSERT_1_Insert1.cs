using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1 : QueryBasis<R0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.APOLICES
            VALUES (:APOLICES-COD-CLIENTE ,
            :APOLICES-NUM-APOLICE ,
            :APOLICES-NUM-ITEM ,
            :APOLICES-COD-MODALIDADE ,
            :APOLICES-ORGAO-EMISSOR ,
            :APOLICES-RAMO-EMISSOR ,
            :APOLICES-COD-PRODUTO ,
            :APOLICES-NUM-APOL-ANTERIOR ,
            :APOLICES-NUM-BILHETE ,
            :APOLICES-TIPO-SEGURO ,
            :APOLICES-TIPO-APOLICE ,
            :APOLICES-TIPO-CALCULO ,
            :APOLICES-IND-SORTEIO ,
            :APOLICES-NUM-ATA ,
            :APOLICES-ANO-ATA ,
            :APOLICES-IND-ENDOS-MANUAL ,
            :APOLICES-PCT-DESC-PREMIO ,
            :APOLICES-PCT-IOCC ,
            :APOLICES-TIPO-COSSEGURO-CED,
            :APOLICES-QTD-COSSEGURADORA ,
            :APOLICES-PCT-COSSEGURO-CED ,
            NULL ,
            NULL ,
            CURRENT_TIMESTAMP ,
            NULL )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICES VALUES ({FieldThreatment(this.APOLICES_COD_CLIENTE)} , {FieldThreatment(this.APOLICES_NUM_APOLICE)} , {FieldThreatment(this.APOLICES_NUM_ITEM)} , {FieldThreatment(this.APOLICES_COD_MODALIDADE)} , {FieldThreatment(this.APOLICES_ORGAO_EMISSOR)} , {FieldThreatment(this.APOLICES_RAMO_EMISSOR)} , {FieldThreatment(this.APOLICES_COD_PRODUTO)} , {FieldThreatment(this.APOLICES_NUM_APOL_ANTERIOR)} , {FieldThreatment(this.APOLICES_NUM_BILHETE)} , {FieldThreatment(this.APOLICES_TIPO_SEGURO)} , {FieldThreatment(this.APOLICES_TIPO_APOLICE)} , {FieldThreatment(this.APOLICES_TIPO_CALCULO)} , {FieldThreatment(this.APOLICES_IND_SORTEIO)} , {FieldThreatment(this.APOLICES_NUM_ATA)} , {FieldThreatment(this.APOLICES_ANO_ATA)} , {FieldThreatment(this.APOLICES_IND_ENDOS_MANUAL)} , {FieldThreatment(this.APOLICES_PCT_DESC_PREMIO)} , {FieldThreatment(this.APOLICES_PCT_IOCC)} , {FieldThreatment(this.APOLICES_TIPO_COSSEGURO_CED)}, {FieldThreatment(this.APOLICES_QTD_COSSEGURADORA)} , {FieldThreatment(this.APOLICES_PCT_COSSEGURO_CED)} , NULL , NULL , CURRENT_TIMESTAMP , NULL )";

            return query;
        }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string APOLICES_NUM_ITEM { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string APOLICES_NUM_APOL_ANTERIOR { get; set; }
        public string APOLICES_NUM_BILHETE { get; set; }
        public string APOLICES_TIPO_SEGURO { get; set; }
        public string APOLICES_TIPO_APOLICE { get; set; }
        public string APOLICES_TIPO_CALCULO { get; set; }
        public string APOLICES_IND_SORTEIO { get; set; }
        public string APOLICES_NUM_ATA { get; set; }
        public string APOLICES_ANO_ATA { get; set; }
        public string APOLICES_IND_ENDOS_MANUAL { get; set; }
        public string APOLICES_PCT_DESC_PREMIO { get; set; }
        public string APOLICES_PCT_IOCC { get; set; }
        public string APOLICES_TIPO_COSSEGURO_CED { get; set; }
        public string APOLICES_QTD_COSSEGURADORA { get; set; }
        public string APOLICES_PCT_COSSEGURO_CED { get; set; }

        public static void Execute(R0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1 r0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1)
        {
            var ths = r0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}