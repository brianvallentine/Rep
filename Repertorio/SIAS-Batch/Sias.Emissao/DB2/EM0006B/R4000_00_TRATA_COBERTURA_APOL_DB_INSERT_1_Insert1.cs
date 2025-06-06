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
    public class R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COBERAPOL
            VALUES (:V0COBA-NUM-APOL ,
            :V0COBA-NRENDOS ,
            :V0COBA-NUM-ITEM ,
            :V0COBA-OCORHIST ,
            :V0COBA-RAMOFR ,
            :V0COBA-MODALIFR ,
            :V0COBA-COD-COBER ,
            :V0COBA-IMP-SEG-IX ,
            :V0COBA-PRM-TAR-IX ,
            :V0COBA-IMP-SEG-VR ,
            :V0COBA-PRM-TAR-VR ,
            :V0COBA-PCT-COBERT ,
            :V0COBA-FATOR-MULT ,
            :V0COBA-DTINIVIG ,
            :V0COBA-DTTERVIG ,
            :V0COBA-COD-EMPRESA:VIND-COD-EMP,
            CURRENT TIMESTAMP ,
            :V0COBA-SITREG)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERAPOL VALUES ({FieldThreatment(this.V0COBA_NUM_APOL)} , {FieldThreatment(this.V0COBA_NRENDOS)} , {FieldThreatment(this.V0COBA_NUM_ITEM)} , {FieldThreatment(this.V0COBA_OCORHIST)} , {FieldThreatment(this.V0COBA_RAMOFR)} , {FieldThreatment(this.V0COBA_MODALIFR)} , {FieldThreatment(this.V0COBA_COD_COBER)} , {FieldThreatment(this.V0COBA_IMP_SEG_IX)} , {FieldThreatment(this.V0COBA_PRM_TAR_IX)} , {FieldThreatment(this.V0COBA_IMP_SEG_VR)} , {FieldThreatment(this.V0COBA_PRM_TAR_VR)} , {FieldThreatment(this.V0COBA_PCT_COBERT)} , {FieldThreatment(this.V0COBA_FATOR_MULT)} , {FieldThreatment(this.V0COBA_DTINIVIG)} , {FieldThreatment(this.V0COBA_DTTERVIG)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0COBA_COD_EMPRESA))}, CURRENT TIMESTAMP , {FieldThreatment(this.V0COBA_SITREG)})";

            return query;
        }
        public string V0COBA_NUM_APOL { get; set; }
        public string V0COBA_NRENDOS { get; set; }
        public string V0COBA_NUM_ITEM { get; set; }
        public string V0COBA_OCORHIST { get; set; }
        public string V0COBA_RAMOFR { get; set; }
        public string V0COBA_MODALIFR { get; set; }
        public string V0COBA_COD_COBER { get; set; }
        public string V0COBA_IMP_SEG_IX { get; set; }
        public string V0COBA_PRM_TAR_IX { get; set; }
        public string V0COBA_IMP_SEG_VR { get; set; }
        public string V0COBA_PRM_TAR_VR { get; set; }
        public string V0COBA_PCT_COBERT { get; set; }
        public string V0COBA_FATOR_MULT { get; set; }
        public string V0COBA_DTINIVIG { get; set; }
        public string V0COBA_DTTERVIG { get; set; }
        public string V0COBA_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0COBA_SITREG { get; set; }

        public static void Execute(R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1 r4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}