using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTPRE
            VALUES (:V0CHIS-COD-EMPR ,
            :V0CHIS-CONGENER ,
            :V0CHIS-NUM-APOL ,
            :V0CHIS-NUM-ENDS ,
            :V0CHIS-NRPARCEL ,
            :V0CHIS-OCORHIST ,
            :V0CHIS-OPERACAO ,
            :V0CHIS-DAT-MOVT ,
            :V0CHIS-TIP-SEGU ,
            :V0CHIS-PRM-TARF ,
            :V0CHIS-VAL-DESC ,
            :V0CHIS-VLPRMLIQ ,
            :V0CHIS-VLADIFRA ,
            :V0CHIS-VLCOMISS ,
            :V0CHIS-VLPRMTOT ,
            CURRENT TIMESTAMP ,
            :V0CHIS-DTQITBCO:VIND-DTQITBCO,
            :V0CHIS-SIT-FINC:VIND-SIT-FINC,
            :V0CHIS-SIT-LIBR:VIND-SIT-LIBR,
            :V0CHIS-NUM-OCOR:VIND-NUM-OCOR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES ({FieldThreatment(this.V0CHIS_COD_EMPR)} , {FieldThreatment(this.V0CHIS_CONGENER)} , {FieldThreatment(this.V0CHIS_NUM_APOL)} , {FieldThreatment(this.V0CHIS_NUM_ENDS)} , {FieldThreatment(this.V0CHIS_NRPARCEL)} , {FieldThreatment(this.V0CHIS_OCORHIST)} , {FieldThreatment(this.V0CHIS_OPERACAO)} , {FieldThreatment(this.V0CHIS_DAT_MOVT)} , {FieldThreatment(this.V0CHIS_TIP_SEGU)} , {FieldThreatment(this.V0CHIS_PRM_TARF)} , {FieldThreatment(this.V0CHIS_VAL_DESC)} , {FieldThreatment(this.V0CHIS_VLPRMLIQ)} , {FieldThreatment(this.V0CHIS_VLADIFRA)} , {FieldThreatment(this.V0CHIS_VLCOMISS)} , {FieldThreatment(this.V0CHIS_VLPRMTOT)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DTQITBCO?.ToInt() == -1 ? null : this.V0CHIS_DTQITBCO))},  {FieldThreatment((this.VIND_SIT_FINC?.ToInt() == -1 ? null : this.V0CHIS_SIT_FINC))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V0CHIS_SIT_LIBR))},  {FieldThreatment((this.VIND_NUM_OCOR?.ToInt() == -1 ? null : this.V0CHIS_NUM_OCOR))})";

            return query;
        }
        public string V0CHIS_COD_EMPR { get; set; }
        public string V0CHIS_CONGENER { get; set; }
        public string V0CHIS_NUM_APOL { get; set; }
        public string V0CHIS_NUM_ENDS { get; set; }
        public string V0CHIS_NRPARCEL { get; set; }
        public string V0CHIS_OCORHIST { get; set; }
        public string V0CHIS_OPERACAO { get; set; }
        public string V0CHIS_DAT_MOVT { get; set; }
        public string V0CHIS_TIP_SEGU { get; set; }
        public string V0CHIS_PRM_TARF { get; set; }
        public string V0CHIS_VAL_DESC { get; set; }
        public string V0CHIS_VLPRMLIQ { get; set; }
        public string V0CHIS_VLADIFRA { get; set; }
        public string V0CHIS_VLCOMISS { get; set; }
        public string V0CHIS_VLPRMTOT { get; set; }
        public string V0CHIS_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V0CHIS_SIT_FINC { get; set; }
        public string VIND_SIT_FINC { get; set; }
        public string V0CHIS_SIT_LIBR { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string V0CHIS_NUM_OCOR { get; set; }
        public string VIND_NUM_OCOR { get; set; }

        public static void Execute(R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1 r2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}