using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1 : QueryBasis<R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOITENSINC
            VALUES (:V0APIN-COD-EMPRESA ,
            :V0APIN-NUM-APOL ,
            :V0APIN-NRENDOS ,
            :V0APIN-NUM-RISCO ,
            :V0APIN-CODCOBINC ,
            :V0APIN-SUBRIS ,
            :V0APIN-NRITEM ,
            :V0APIN-COD-PLANTA ,
            :V0APIN-COD-RUBRICA ,
            :V0APIN-CLASOCUPA ,
            :V0APIN-CLASCONST ,
            :V0APIN-DTINIVIG ,
            :V0APIN-DTTERVIG ,
            :V0APIN-IMP-SEG-IX ,
            :V0APIN-PRM-TAR-IX ,
            :V0APIN-TIPCOND ,
            :V0APIN-TAXA-PRM ,
            :V0APIN-TIPO-TAXA ,
            :V0APIN-PCDESCON ,
            :V0APIN-TPDESCON ,
            :V0APIN-PCADICIO ,
            :V0APIN-PCVALRISC,
            :V0APIN-COEFAGRAV,
            :V0APIN-TIPRAZO ,
            :V0APIN-SITUACAO ,
            CURRENT TIMESTAMP ,
            :V0APIN-TPMOVTO,
            :V0APIN-TPOCUP,
            :V0APIN-SPOCUP,
            :V0APIN-QTPAVTO,
            :V0APIN-OCORHIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOITENSINC VALUES ({FieldThreatment(this.V0APIN_COD_EMPRESA)} , {FieldThreatment(this.V0APIN_NUM_APOL)} , {FieldThreatment(this.V0APIN_NRENDOS)} , {FieldThreatment(this.V0APIN_NUM_RISCO)} , {FieldThreatment(this.V0APIN_CODCOBINC)} , {FieldThreatment(this.V0APIN_SUBRIS)} , {FieldThreatment(this.V0APIN_NRITEM)} , {FieldThreatment(this.V0APIN_COD_PLANTA)} , {FieldThreatment(this.V0APIN_COD_RUBRICA)} , {FieldThreatment(this.V0APIN_CLASOCUPA)} , {FieldThreatment(this.V0APIN_CLASCONST)} , {FieldThreatment(this.V0APIN_DTINIVIG)} , {FieldThreatment(this.V0APIN_DTTERVIG)} , {FieldThreatment(this.V0APIN_IMP_SEG_IX)} , {FieldThreatment(this.V0APIN_PRM_TAR_IX)} , {FieldThreatment(this.V0APIN_TIPCOND)} , {FieldThreatment(this.V0APIN_TAXA_PRM)} , {FieldThreatment(this.V0APIN_TIPO_TAXA)} , {FieldThreatment(this.V0APIN_PCDESCON)} , {FieldThreatment(this.V0APIN_TPDESCON)} , {FieldThreatment(this.V0APIN_PCADICIO)} , {FieldThreatment(this.V0APIN_PCVALRISC)}, {FieldThreatment(this.V0APIN_COEFAGRAV)}, {FieldThreatment(this.V0APIN_TIPRAZO)} , {FieldThreatment(this.V0APIN_SITUACAO)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0APIN_TPMOVTO)}, {FieldThreatment(this.V0APIN_TPOCUP)}, {FieldThreatment(this.V0APIN_SPOCUP)}, {FieldThreatment(this.V0APIN_QTPAVTO)}, {FieldThreatment(this.V0APIN_OCORHIST)})";

            return query;
        }
        public string V0APIN_COD_EMPRESA { get; set; }
        public string V0APIN_NUM_APOL { get; set; }
        public string V0APIN_NRENDOS { get; set; }
        public string V0APIN_NUM_RISCO { get; set; }
        public string V0APIN_CODCOBINC { get; set; }
        public string V0APIN_SUBRIS { get; set; }
        public string V0APIN_NRITEM { get; set; }
        public string V0APIN_COD_PLANTA { get; set; }
        public string V0APIN_COD_RUBRICA { get; set; }
        public string V0APIN_CLASOCUPA { get; set; }
        public string V0APIN_CLASCONST { get; set; }
        public string V0APIN_DTINIVIG { get; set; }
        public string V0APIN_DTTERVIG { get; set; }
        public string V0APIN_IMP_SEG_IX { get; set; }
        public string V0APIN_PRM_TAR_IX { get; set; }
        public string V0APIN_TIPCOND { get; set; }
        public string V0APIN_TAXA_PRM { get; set; }
        public string V0APIN_TIPO_TAXA { get; set; }
        public string V0APIN_PCDESCON { get; set; }
        public string V0APIN_TPDESCON { get; set; }
        public string V0APIN_PCADICIO { get; set; }
        public string V0APIN_PCVALRISC { get; set; }
        public string V0APIN_COEFAGRAV { get; set; }
        public string V0APIN_TIPRAZO { get; set; }
        public string V0APIN_SITUACAO { get; set; }
        public string V0APIN_TPMOVTO { get; set; }
        public string V0APIN_TPOCUP { get; set; }
        public string V0APIN_SPOCUP { get; set; }
        public string V0APIN_QTPAVTO { get; set; }
        public string V0APIN_OCORHIST { get; set; }

        public static void Execute(R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1 r2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1)
        {
            var ths = r2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}